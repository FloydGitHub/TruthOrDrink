using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Models;
using TruthOrDrink.Pages.QuestionCrudPages;

namespace TruthOrDrink.MVVM.VieuwModels
{
     public class QuestionIndexViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
                LoadQuestions();

            }
        }

        public ObservableCollection<Question> _questions;
        public ObservableCollection<Question> Questions
        {
            get => _questions;
            set
            {
                _questions = value;
                OnPropertyChanged();
            }
        }


        public Command CreateQuestionCommand { get; }
        public Command BackCommand { get; }
         
        public QuestionIndexViewModel()
        {
            Questions = new ObservableCollection<Question>();
            CreateQuestionCommand = new Command(CreateQuestion);
            BackCommand = new Command(GoBack);
        }


        public void LoadQuestions()
        {
            if (CurrentUser != null)
            {

                var questionsFromUser = Question.GetQuestionsFromUser(CurrentUser.Id);
                Questions = new ObservableCollection<Question>(questionsFromUser);
            }
        }

       

        public void CreateQuestion()
        {
            // Navigatie naar de createpagina
            App.Current.MainPage.Navigation.PushAsync(new QuestionCreatePage(CurrentUser, this));
        }

        public void GoBack()
        {
            // Navigatie terug
            App.Current.MainPage.Navigation.PopAsync();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
    }
}