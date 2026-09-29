namespace Gurin_0._5.Models
{
    public class OutputModel
    {

        public InputModel Input { get; set; }

        public int? Sum
        {
            get
            {
                if (Input == null) return null;

                return (Input.Number1 + Input.Number2);
            }

        }

    }
}
