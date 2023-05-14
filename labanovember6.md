Установил Node.js с официального сайта. 
Затем установил Vue.js с помощью команды: npm install -g vue-cli
Создал новый проект Vue.js с помощью следующих команд в терминале: vue init webpack my-project cd my-project npm install 
Чтобы запустить приложение, прописал следующую команду: npm run dev 
Открыл файл конфигурации Nginx nginx.conf
В разделе http добавил: server { listen 80; server_name corm.com; location / { proxy_pass http://127.0.0.1:8080; proxy_http_version 1.1; proxy_set_header Upgrade $http_upgrade; proxy_set_header Connection 'upgrade'; proxy_set_header Host $host; proxy_cache_bypass $http_upgrade; } } 
Сохранил файл конфигурации и перезапустил Nginx. Запустил приложение Vue.js на порту 8080
Закинул все в докер контейнер.
