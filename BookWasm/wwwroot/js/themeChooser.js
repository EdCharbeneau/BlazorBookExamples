window.themeChooser = {
    setTheme: function (themeName) {

        // Build the new css link         
        let newLink = document.createElement("link");
        newLink.setAttribute("id", "theme");
        newLink.setAttribute("rel", "stylesheet");
        newLink.setAttribute("type", "text/css");
        newLink.setAttribute("href", `css/${themeName}.css`);

        // Remove and replace the theme         
        let head = document.getElementsByTagName("head")[0];
        head.querySelector("#theme").remove();
        head.appendChild(newLink);
    }
}