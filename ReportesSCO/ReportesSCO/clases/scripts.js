(function (global, undefined) {

    function OnClientFilter(sender, args) {
        /*global.logEvent("Filter event: The user searched for <strong>\"" + args.get_text() + "\"</strong> keyword.");*/
    }

    global.OnClientFilter = OnClientFilter;

})(window);