function loadProgressBarTheme(args) {
    var selectedTheme = location.hash.split('/')[1];
    selectedTheme = selectedTheme ? selectedTheme : 'Tailwind3';
    args.progressBar.theme = (selectedTheme.charAt(0).toUpperCase() +
        selectedTheme.slice(1)).replace(/-dark/i, 'Dark').replace(/contrast/i, 'Contrast').replace(/-highContrast/i, 'HighContrast').replace(/5.3/i, '5');
    return selectedTheme;
}; 