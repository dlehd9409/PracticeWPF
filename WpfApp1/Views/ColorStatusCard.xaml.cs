using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Views
{
    /// <summary>
    /// ColorStatusCard.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ColorStatusCard : UserControl
    {
        public ColorStatusCard()
        {
            InitializeComponent();
        }

        // 의존성 속성: 외부(MainWindow)에서 값을 꽂아넣을 수 있는 '입력 단자'를 만듭니다.
        public static readonly DependencyProperty CardBrushProperty =
            DependencyProperty.Register(
                "CardBrush",           // 속성 이름
                typeof(Brush),         // 데이터 타입
                typeof(ColorStatusCard), // 소유자 클래스
                new PropertyMetadata(Brushes.Gray)); // 기본값

        // 일반 프로퍼티처럼 보이지만 내부적으로는 GetValue, SetValue를 사용하는 래퍼입니다.
        public Brush CardBrush
        {
            get => (Brush)GetValue(CardBrushProperty);
            set => SetValue(CardBrushProperty, value);
        }

        // 1. 문자열을 위한 의존성 속성 등록
        public static readonly DependencyProperty CardNameProperty =
            DependencyProperty.Register(
                "CardName",              // 속성 이름
                typeof(string),          // 이번에는 string 타입입니다!
                typeof(ColorStatusCard),
                new PropertyMetadata("색상 미지정")); // 기본값 설정

        // 2. 래퍼 프로퍼티
        public string CardName
        {
            get => (string)GetValue(CardNameProperty);
            set => SetValue(CardNameProperty, value);
        }
    }
}
