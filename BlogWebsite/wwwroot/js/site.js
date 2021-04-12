// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

if ('caches' in window) {
    const cacheName = 'offlineSaved-v1';
    let offlineBtn = $("#saveOffline");

    let checkCache = (url, cacheChange = true) => {
        caches.open(cacheName).then((cache) => {
            cache.match(url).then((response) => {
                let match = ('object' == typeof response);
                if (match) {
                    if (cacheChange)
                        cache.delete(window.location.href);

                    if (cacheChange) {
                        offlineBtn.val('📌 Save Offline');
                        offlineBtn.attr('aria-label', 'Save Offline');
                    } else {
                        offlineBtn.val('❌ Remove From cache');
                    }

                } else {
                    if (cacheChange)
                        cache.add(window.location.href);

                    if (cacheChange) {
                        offlineBtn.val('❌ Remove From cache');
                    } else {
                        offlineBtn.val('📌 Save Offline');
                        offlineBtn.attr('aria-label', 'Save Offline');
                    }
                }
            });
        });
    }

    offlineBtn.on("click", () => {
        checkCache(window.location.href);
    });

    checkCache(window.location.href, false);

    offlineBtn.removeAttr('hidden');
}



function share() {
    if (!("share" in navigator)) {
        alert('Web Share API not supported.');
        return;
    }

    navigator.share({
        title: 'CV Blog Website',
        text: 'Love Reading? Then check out this website for amazing blog posts!!',
        url: '/'
    })
        .then(() => console.log('Successful share'))
        .catch(error => console.log('Error sharing:', error));
}

