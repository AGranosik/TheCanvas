namespace backend.Logic.Common
{
    public interface ISessionResolver
    {
        Guid GetSessionId();
        void SetSessionId(Guid sessionId);
    }

    public class SessionResolver : ISessionResolver
    {
        private Guid? _sessionId = null;
        public Guid GetSessionId()
            => _sessionId ?? throw new ArgumentException("Missing session id in cookies.");

        public void SetSessionId(Guid sessionId)
        {
            _sessionId = sessionId;
        }
    }
}
