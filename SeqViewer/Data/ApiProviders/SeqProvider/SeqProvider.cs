using Seq.Api;
using Seq.Api.Model.Events;

namespace SeqViewer.Data.ApiProviders.SeqProvider
{
    public class SeqProvider : ISeqProvider
    {
        private readonly SeqConnection _connection;

        public SeqProvider()
        {
            _connection = new SeqConnection("https://seq.stoievservices.de/", "fNlpO0fBfeM7yqvHN14K");
        }

        public async Task<IQueryable<EventEntity>> GetSeqsAsync()
        {
            try
            {
                var eventsList = await _connection.Events.ListAsync();
                return eventsList.AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EventEntity>().AsQueryable();
            }
        }

        public async Task<IQueryable<EventEntity>> GetSeqsWithFilterAsync(string filterString, int count)
        {
            try
            {
                var resultSet = await _connection.Events.ListAsync(filter: filterString, count: count);
                return resultSet.AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EventEntity>().AsQueryable();
            }
        }
    }
}