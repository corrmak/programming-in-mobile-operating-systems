В-первую очередь я определил точку монтирования Volume внутри контейнера.

Внёс изменения в Dockerfile, где добавил команду VOLUME, которая указывает точку монтирования для VOLUME: VOLUME /app Собрал образ Docker, используя измененный Dockerfile

Ввёл: docker build -t nginx-dock 

Создал volume используя: docker volume create storage

Запустил контейнер подключив volume: docker run -v storage:/app -p 8080:80 nginx Файлы из Volume доступны внутри контейнера по пути /app. 

А мой index.html будет доступен по пути /app/index.html

Копирую данные index.html внутрь volume:

docker run -v storage:/app -v /Users/Win10Pro/desktop/lab5:/data --rm alpine sh -c "cp /data/index.html /app/"

Я использовал образ alpine для временного контейнера и команды sh -c для выполнения команд внутри контейнера

Теперь проверяю, что index.html подгрузился внутрь Volume, запустив временный конейнер и проверил наличие файла docker run -v storage:/app --rm alpine sh -c "ls /app"

Файл index.html отображается в выводе команды, он подгружен, всё.
