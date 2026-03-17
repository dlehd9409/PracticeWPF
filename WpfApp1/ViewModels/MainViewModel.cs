using WpfApp1.Helpers;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Brush _boxColor = Brushes.Gray; // 초기 색상

        public Brush BoxColor
        {
            get => _boxColor;
            set
            {
                _boxColor = value;
                OnPropertyChanged(nameof(BoxColor));
            }
        }

        public ICommand ChangeColorCommand { get; }

        public MainViewModel()
        {
            // 첫 번째 인자: 실행 로직 (Execute)
            // 두 번째 인자: 실행 가능 조건 (CanExecute)
            ChangeColorCommand = new RelayCommand(
                execute: colorName => {
                    if (colorName is string name)
                    {
                        var brush = (Brush)new BrushConverter().ConvertFromString(name);
                        BoxColor = brush;
                    }
                },
                canExecute: colorName => {
                    if (colorName is string name)
                    {
                        // 현재 색상과 버튼의 색상이 다를 때만 true 반환 (버튼 활성화)
                        var targetBrush = (Brush)new BrushConverter().ConvertFromString(name);

                        // Brush끼리의 비교는 ToString()이나 색상 코드 비교가 확실합니다.
                        return BoxColor.ToString() != targetBrush.ToString();
                    }
                    return true;
                }
            );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
