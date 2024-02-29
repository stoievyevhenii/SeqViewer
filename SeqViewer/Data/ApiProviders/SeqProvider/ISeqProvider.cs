using Seq.Api.Model.Events;

namespace SeqViewer.Data.ApiProviders.SeqProvider
{
    public interface ISeqProvider
    {
        public Task<IQueryable<EventEntity>> GetSeqsAsync();
    }
}