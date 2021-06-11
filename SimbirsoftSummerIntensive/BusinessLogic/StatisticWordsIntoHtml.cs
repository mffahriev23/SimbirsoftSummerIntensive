using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using SimbirsoftSummerIntensive.Core.DBModels;
using SimbirsoftSummerIntensive.Infrastructure.DataForStatistic;
using SimbirsoftSummerIntensive.Infrastructure.DB.Interfaces;
using SimbirsoftSummerIntensive.Infrastructure.DownloadResource;
using SimbirsoftSummerIntensive.Infrastructure.ModifyText;
using SimbirsoftSummerIntensive.Infrastructure.Statistic;

namespace SimbirsoftSummerIntensive.CLI.BusinessLogic
{
    public class StatisticWordsIntoHtml : IBusinessLogic<IDictionary<string, int>>
    {
        private readonly string _sourcePath;
        private readonly ILogger _logger;
        private readonly IResourseRepository _resourseService;
        private readonly IStatisticFieldRepository _statisticFieldService;

        private IDownloadResource resourceService;
        private readonly IDataForStatistic getterDataForStatistic = new StatisticWordsIntoText();
        private readonly IGetStatisticText getterStatistic = new StatisticText();

        private string _dataFilePath;
        private string _text;
        private Resource _resourse;
        private IEnumerable<string> _wordsInText;

        public StatisticWordsIntoHtml(string sourcePath, string dataFilePath, ILogger logger, IResourseRepository resourseService,
                                      IStatisticFieldRepository statisticFieldService)
        {
            _sourcePath = sourcePath;
            _dataFilePath = dataFilePath;
            _logger = logger;
            _resourseService = resourseService;
            _statisticFieldService = statisticFieldService;

        }

        public async Task<IDictionary<string, int>> GetFinalData()
        {
            await _resourseService.Add(new Resource { SourcePath = _sourcePath });
            _resourse = await _resourseService.GetFreshResourse();
            _logger.Information("Ссылка на ресурс успешно сохранена в базе");

            resourceService = new DownloadFileByUrl(_dataFilePath);
            await resourceService.DownloadResource(_sourcePath);
            _logger.Information("Ресурс получен");

            _resourse.FilePath = _dataFilePath;
            await _resourseService.Update(_resourse);
            _logger.Information("Путь к ресурсу сохранён в базу");

            _text = await resourceService.GetDataFromResourse();
            _logger.Information("Текст из ресурса считан");

            ModifyText(ref _text, new GetClearedCss(), new GetClearedJS(), new GetClearedTags(), new GetUpperWords());
            _wordsInText = getterDataForStatistic.GetDataForStatistic(_text);
            _logger.Information("Текст успешно обработан");

            IDictionary<string, int> statistic = getterStatistic.GetStatisticText(_wordsInText);
            _logger.Information("Статистика получена");

           bool resultStatistic = await _statisticFieldService.AddRange(statistic.Select(x => new StatisticField 
            { 
                StatisticElement = x.Key, 
                Count = x.Value, 
                ResourseId = _resourse.Id 
            }));
            _logger.Information("Стистика  сохранена в базу");

            if (resultStatistic)
                return statistic;
            else
            {
                _logger.Information(JsonConvert.SerializeObject(statistic));
                throw new Exception("Не удалось созранить статистику в базу. Статистику ищите в логах.");
            }
        }

        private void ModifyText(ref string text, params IModifyText[] modifies)
        {
            foreach (IModifyText modify in modifies)
                modify.GetModifiedText(ref text);
        }
    }
}
