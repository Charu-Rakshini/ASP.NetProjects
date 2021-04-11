const cacheName = 'my-site-cache-v1';let urlsToCache = [    '/',    '/css/site.css'];self.addEventListener('install', (event) => {    console.info('Service Worker Installing...');    event.waitUntil(        caches.open(cacheName)            .then(function (cache) {
                console.log('Opened cache');
                return cache.addAll(urlsToCache);

            })    );    console.info('Caching Started...');});//self.addEventListener('fetch', function (event) {//    event.respondWith(//        caches.match(event.request)//            .then(function (response) {
//                if (response) { return response; } const netResponse = fetch(event.request); caches.open(cacheName).then((cache) => {
//                    caches.add(event.request)
//                })//    )