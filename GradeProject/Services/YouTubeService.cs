using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using GradeProject.Data.Models;

public class YouTubeApiService
{
    private readonly YouTubeService _youTubeService;
    private readonly string _channelId;
    private readonly ILogger<YouTubeApiService> _logger;

    public YouTubeApiService(IConfiguration configuration, ILogger<YouTubeApiService> logger)
    {
        _youTubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = configuration["YouTube:ApiKey"]
        });

        _channelId = configuration["YouTube:ChannelId"];
        _logger = logger;
    }

    public async Task<List<YouTubeVideo>> GetLatestVideosAsync()
    {
        var searchRequest = _youTubeService.Search.List("snippet");
        searchRequest.ChannelId = _channelId;
        searchRequest.MaxResults = 5;
        searchRequest.Order = SearchResource.ListRequest.OrderEnum.Date;
        searchRequest.Type = "video";

        var searchResponse = await searchRequest.ExecuteAsync();

        var videos = new List<YouTubeVideo>();
        foreach (var item in searchResponse.Items)
        {
            videos.Add(new YouTubeVideo
            {
                Title = item.Snippet.Title,
                Description = item.Snippet.Description,
                ThumbnailUrl = item.Snippet.Thumbnails.Default__.Url,
                VideoUrl = $"https://www.youtube.com/watch?v={item.Id.VideoId}"
            });
        }

        return videos;
    }
}