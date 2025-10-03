# Используем официальный образ PostgreSQL
FROM postgres:16

# Установим переменные окружения для PostgreSQL
ENV POSTGRES_DB=mydb
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=postgres

# Порт для PostgreSQL
EXPOSE 5432

# Создаем volume для хранения данных
VOLUME ["/var/lib/postgresql/data"]

# Команда для запуска PostgreSQL
CMD ["postgres"]