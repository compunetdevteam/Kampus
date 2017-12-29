using Kampus.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kampus.ViewModels
{
    public class CardViewModel
    {
        public IList<CardDataModel> CardDataModels { get; set; }
        public object SelectedItem { get; set; }

        public CardViewModel()
        {
            CardDataModels = new List<CardDataModel>();
            GenerateList();
        }

        private void GenerateList()
        {
            CardDataModels = new ObservableCollection<CardDataModel>
            {
                new CardDataModel
                {
                    HeadTitle = "Faculty",
                    HeadLines = "Science",
                    HeadLineDescription = "No description"
                },
                new CardDataModel
                {
                    HeadTitle = "Department",
                    HeadLines = "Computer Science",
                    HeadLineDescription = "No description"
                },
                new CardDataModel
                {
                    HeadTitle = "Department",
                    HeadLines = "Computer Science",
                    HeadLineDescription = "No description"
                },
            };
        }
    }
}
