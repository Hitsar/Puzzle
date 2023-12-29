mergeInto(LibraryManager.library, {
    GetLang: function()
    {
        var lang = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(lang) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(lang, buffer, bufferSize);
        return buffer;
    },

    SaveExtern: function(date){
        var dateString = UTF8ToString(date);
        var myObj = JSON.parse(dateString);
        player.setData(myObj);
    }

    LoadExtern: function(){
        player.getData().then(_date => {
            const myJson = JSON.stringify(_date);
            myGameInstance.SendMessage("ProgressLoader", "Load", myJson);
        });
    }
});