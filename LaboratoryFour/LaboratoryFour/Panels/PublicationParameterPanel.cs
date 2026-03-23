using LaboratoryThirdModel;

namespace View.Panels
{
    public abstract partial class PublicationParameterPanel : UserControl
    {
        public PublicationParameterPanel()
        {
            InitializeComponent();
        }

        public abstract void ClearValues();

        public abstract void FillRandomValue(Random random);

        public abstract PublicationBase CreatePublication();
    }
}
