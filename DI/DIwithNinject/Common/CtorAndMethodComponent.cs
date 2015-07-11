namespace Common
{
    public class CtorAndMethodComponent : IDomComponent
    {
        private readonly string _message;

        public CtorAndMethodComponent()
        {
            _message = "default ctor";
        }

        public CtorAndMethodComponent(string message)
        {
            _message = message;
        }

        public string Execute()
        {
            return _message;
        }
    }
}