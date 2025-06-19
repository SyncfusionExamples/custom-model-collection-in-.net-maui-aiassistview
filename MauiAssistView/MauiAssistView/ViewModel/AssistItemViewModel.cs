using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Syncfusion.Maui.AIAssistView;

namespace MauiAssistView
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields
        ObservableCollection<ItemModel> assistItemsCollection;
        #endregion

        #region Constructor
        public ViewModel()
        {
            assistItemsCollection = new ObservableCollection<ItemModel>();
            this.GenerateAssistItems();
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the collection of messages of a conversation.
        /// </summary>
        public ObservableCollection<ItemModel> AssistItemsCollection
        {
            get
            {
                return assistItemsCollection;
            }

            set
            {
                assistItemsCollection = value;
                RaisePropertyChanged(nameof(AssistItemsCollection));
            }
        }
        #endregion

        #region INotifyPropertyChanged

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        #endregion

        #region Item Generation
        private async void GenerateAssistItems()
        {
            // Adding a request item
            ItemModel requestItem = new ItemModel()
            {
                Prompt = "Types of listening",
                IsRequested = true
            };

            // Add the request item to the collection
            this.assistItemsCollection.Add(requestItem);

            // Generating response item
            await GetResult(requestItem);
        }

        private async Task GetResult(ItemModel requestItem)
        {
            await Task.Delay(1000).ConfigureAwait(true);

            ItemModel responseItem = new ItemModel()
            {
                Response = "Types of Listening : For a good communication, it is not only enough to convey the information efficiently, but it also needs to include good listening skill. Common types of Listening are Active listening and Passive listening.",
                IsRequested = false,
                PromptItem = requestItem,
            };
 
            // Add the response item to the collection
            this.assistItemsCollection.Add(responseItem);
        }
        #endregion
    }
}