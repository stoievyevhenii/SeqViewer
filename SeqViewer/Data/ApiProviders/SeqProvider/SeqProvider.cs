using Seq.Api;
using Seq.Api.Model.Events;

using System.Diagnostics;
using System.Text.Json;

namespace SeqViewer.Data.ApiProviders.SeqProvider
{
    public class SeqProvider : ISeqProvider
    {
        public async Task<IQueryable<EventEntity>> GetSeqsAsync()
        {
            try
            {
                var connection = new SeqConnection("https://seq.stoievservices.de/", "fNlpO0fBfeM7yqvHN14K");
                var eventsList = await connection.Events.ListAsync();

                foreach (var ev in eventsList)
                {
                    Debug.WriteLine(JsonSerializer.Serialize(ev));
                }

                return eventsList.AsQueryable();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<EventEntity>().AsQueryable();
            }
        }
    }
}