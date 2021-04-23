const cacheName = 'cache-ToDoWebsite';
const dynamicCache = 'dyn-ToDoWebsite';
let urlsToCache = [
    '/',
    '/css/site.css',
    '/js/site.js'
];

self.addEventListener('install', (event) => {
    console.info('Service Worker Installing...');

    event.waitUntil(
        caches.open(cacheName)
            .then(function (cache) {
                console.log('Opened cache');
                return cache.addAll(urlsToCache);
            })
    );

    console.info('Caching Started...');
});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request)
            .then(function (response) {
                // Cache hit - return response
                if (response) {
                    return response;
                }
                const netResponse = fetch(event.request);
                caches.open(dynamicCache).then((cache) => {
                    // cache.add(event.request);
                });
                return netResponse;
            }
            )
    );
});