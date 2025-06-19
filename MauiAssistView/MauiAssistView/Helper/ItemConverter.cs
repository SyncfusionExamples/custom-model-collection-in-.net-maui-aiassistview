using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Maui.AIAssistView;

namespace MauiAssistView
{
    public class ItemConverter : IAssistItemConverter
    {
        public IAssistItem ConvertToAssistItem(object customItem, SfAIAssistView assistView)
        {
            var assistItem = new AssistItem();
            var item = customItem as ItemModel;
            if (item != null)
            {
                assistItem.Data = item;
                assistItem.IsRequested = item.IsRequested;
                if (item.IsRequested)
                {
                    if (item.Prompt != null)
                    {
                        assistItem.Text = item.Prompt;
                    }
                }
                else
                {
                    if (item.Response != null)
                    {
                        assistItem.Text = item.Response;
                    }
                }
            }
            return assistItem;
        }

        public object ConvertToData(object assistViewItem, SfAIAssistView assistView)
        {
            var item = new ItemModel();
            var assistItem = assistViewItem as AssistItem;
            if (assistItem != null)
            {
                item.IsRequested = assistItem.IsRequested;
                if (item.IsRequested)
                {
                    item.Prompt = assistItem.Text;
                }
                else
                {
                    item.Response = assistItem.Text;
                }
            }
            return item;
        }
    }
}
