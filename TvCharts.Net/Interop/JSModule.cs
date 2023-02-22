using Microsoft.JSInterop;

namespace TvCharts.Net.Interop
{
    internal sealed class JSModule : IJSObjectReference
    {
        private readonly Lazy<Task<IJSObjectReference>> _objectTask;

        internal JSModule(Task<IJSObjectReference> objectTask)
        {
            _objectTask = new Lazy<Task<IJSObjectReference>>(() => objectTask);
        }

        public async ValueTask DisposeAsync()
        {
            await (await _objectTask.Value).DisposeAsync().ConfigureAwait(false);
            GC.SuppressFinalize(this);
        }

        public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
        {
            return await (await _objectTask.Value).InvokeAsync<TValue>(identifier, args).ConfigureAwait(false);
        }

        public async ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
        {
            return await (await _objectTask.Value).InvokeAsync<TValue>(identifier, cancellationToken, args).ConfigureAwait(false);
        }
    }

}
