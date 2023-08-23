mergeInto(LibraryManager.library, {

  ShowBlockAd: function () {
    ysdk.adv.showFullscreenAdv({
      callbacks: {
        onClose: function (wasShown) {
          
        },
        onError: function (error) {
          
        }
      }
    })
  },
});