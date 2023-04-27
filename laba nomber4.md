нашел в интернете уже готовый html файл с использованием js

создал dockerfile в корне репозитория и отредактировал его с помощью этих команд:

FROM nginx

COPY js.html /usr/share/nginx/html

COPY style.css /usr/share/nginx/html

COPY script.js /usr/share/nginx/html

создал docker образ:

docker build -t js

Через "docker desktop" проверил рабочий ли контейнер

Ввёл запуск образа docker run -itd -p 8011:80 --name nginx-dock localhost:5000/nginx:0.0.
