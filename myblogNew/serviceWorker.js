const staticDevCoffee = "Tarik Davulcu";
const assets = [
  "/",
  "/js/app.js"
];

self.addEventListener("install", installEvent => {
  installEvent.waitUntil(
    caches.open(staticDevCoffee).then(cache => {
      //cache.addAll(assets);
    })
  );
});

self.addEventListener("fetch", fetchEvent => {
  fetchEvent.respondWith(
    // caches.match(fetchEvent.request).then(res => {
    //   return res ;
    // })
  );
});
