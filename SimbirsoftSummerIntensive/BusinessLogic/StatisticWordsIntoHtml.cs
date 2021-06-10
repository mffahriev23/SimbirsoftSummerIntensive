using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Serilog;
using SimbirsoftSummerIntensive.Core.DBContext;
using SimbirsoftSummerIntensive.Core.DBModels;
using SimbirsoftSummerIntensive.Infrastructure.DataForStatistic;
using SimbirsoftSummerIntensive.Infrastructure.DB.Interfaces;
using SimbirsoftSummerIntensive.Infrastructure.DB.Repositories;
using SimbirsoftSummerIntensive.Infrastructure.DownloadResource;
using SimbirsoftSummerIntensive.Infrastructure.ModifyText;
using SimbirsoftSummerIntensive.Infrastructure.ReadDataFromFile;
using SimbirsoftSummerIntensive.Infrastructure.Statistic;

namespace SimbirsoftSummerIntensive.CLI.BusinessLogic
{
    public class StatisticWordsIntoHtml : IBusinessLogic<IDictionary<string, int>>
    {
        private readonly string _sourcePath, _dataFolderPath;
        private readonly ILogger _logger;
        private readonly IResourseRepository _resourseService;
        private readonly IStatisticFieldRepository _statisticFieldService;

        private readonly IDownloadResource downloadResource = new DownloadFileByUrl();
        private readonly IGetTextFromFile getterText = new ReadTextFromTextFile();
        private readonly IDataForStatistic getterDataForStatistic = new StatisticWordsIntoText();
        private readonly IGetStatisticText getterStatistic = new StatisticText();

        private string _dataFilePath;
        private string _text;
        private Resource _resourse;
        private List<StatisticField> _statisticFields;
        private IEnumerable<string> _wordsInText;

        public StatisticWordsIntoHtml(string sourcePath, string dataFolderPath, ILogger logger, IResourseRepository resourseService,
                                      IStatisticFieldRepository statisticFieldService)
        {
            _sourcePath = sourcePath;
            _dataFolderPath = dataFolderPath;
            _logger = logger;
            _resourseService = resourseService;
            _statisticFieldService = statisticFieldService;

        }

        public async Task<IDictionary<string, int>> GetFinalData()
        {
            await _resourseService.Add(new Resource { SourcePath = _sourcePath });
            _resourse = await _resourseService.GetFreshResourse();

            _dataFilePath = $"{_dataFolderPath}/{DateTime.Now.ToString("yyyyMMddhhmmssff")}.html";
            await downloadResource.DownloadResource(_sourcePath, _dataFilePath);

            _resourse.FilePath = _dataFilePath;
            await _resourseService.Update(_resourse);

            getterText.SetFilePath(_dataFolderPath);
            _text = await getterText.GetTextFromFile();

            ModifyText(ref _text, new GetClearedTags(), new GetUpperWords());
            _wordsInText = getterDataForStatistic.GetDataForStatistic(_text);
            IDictionary<string, int> statistic = getterStatistic.GetStatisticText(_wordsInText);

            var resultStatistic = await _statisticFieldService.AddRange(statistic.Select(x => new StatisticField 
            { 
                StatisticElement = x.Key, 
                Count = x.Value, 
                ResourseId = _resourse.Id 
            }));

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
