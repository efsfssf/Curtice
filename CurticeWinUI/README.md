<!-- Список диалогов слева -->
        <ListView Grid.Column="0" ItemsSource="{x:Bind ViewModel.Dialogs}" 
          SelectedItem="{x:Bind ViewModel.SelectedDialog, Mode=TwoWay}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="models:Dialog">
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="*"/>
                            <RowDefinition Height="*"/>
                        </Grid.RowDefinitions>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto"/>
                            <ColumnDefinition Width="*"/>
                        </Grid.ColumnDefinitions>
                        <Image Source="{x:Bind Avatar}" Width="50" Height="50"/>
                        <TextBlock Grid.Column="1"
                            Text="{x:Bind Name}"
                            x:Phase="1"
                            Style="{ThemeResource BaseTextBlockStyle}"
                            Margin="12,6,0,0"/>
                        <TextBlock  Grid.Column="1"
                            Grid.Row="1"
                            Text="{x:Bind LastMessage}"
                            x:Phase="2"
                            Style="{ThemeResource BodyTextBlockStyle}"
                            Margin="12,0,0,6"/> 
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>


        <!-- Переписка справа -->
        <StackPanel Grid.Row="1">
            <TextBlock Text="{x:Bind ViewModel.SelectedDialogText, FallbackValue='Пожалуйста, выберите диалог справа'}" />
            <ListView ItemsSource="{x:Bind ViewModel.SelectedDialogMessages}">
                <!-- Здесь вы можете настроить DataTemplate для элементов списка сообщений -->
            </ListView>
            <!-- Поле ввода и кнопка отправки -->
            <StackPanel Orientation="Horizontal">
                <Button Content="Прикрепить" Command="{x:Bind ViewModel.AttachCommand}" />
                <RichEditBox PlaceholderText="Введите сообщение" Width="200" Height="Auto" Margin="8" />
                <Button Content="Отправить" Command="{x:Bind ViewModel.SendCommand}" />
            </StackPanel>
        </StackPanel>