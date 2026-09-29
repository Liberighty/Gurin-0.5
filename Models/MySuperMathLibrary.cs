namespace Gurin_0._5.Models
{
    public class MySuperMathLibrary
    {
        public int A
        {
            get
            {
                return _model.Number1 + _model.Number2;
            }
        }

        public int B
        {
            get
            {
                return A + _model.Number2;
            }
        }

        public int C
        {
            get
            {
                return A * B;
            }
        }

        private InputModel _model;
        public MySuperMathLibrary(InputModel model)
        {
            _model = model;
        }
    }
}
