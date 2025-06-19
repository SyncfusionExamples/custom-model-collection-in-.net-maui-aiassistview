using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAssistView
{
    public class ItemModel : INotifyPropertyChanged
    {
        private string? prompt;
        private string? response;
        private object? promptItem;
        private bool isRequested;
        public string? Prompt
        {
            get { return prompt; }
            set
            {
                prompt = value;
                RaisePropertyChanged(nameof(Prompt));
            }
        }

        public string? Response
        {
            get { return response; }
            set
            {
                response = value;
                RaisePropertyChanged(nameof(Response));
            }
        }

        public bool IsRequested
        {
            get { return isRequested; }
            set
            {
                isRequested = value;
                RaisePropertyChanged(nameof(IsRequested));
            }
        }

        public object? PromptItem
        {
            get { return promptItem; }

            set
            {
                promptItem = value;
                RaisePropertyChanged(nameof(PromptItem));
            }
        }

        // Declare the PropertyChanged event.
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
