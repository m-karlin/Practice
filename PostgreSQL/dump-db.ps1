# Скрипт для создания дампа базы данных PostgreSQL

# Параметры подключения к базе данных
$ContainerName = "postgres-db"
$DatabaseName = "mydb"
$UserName = "postgres"
$DumpFile = "dump.sql"

# Создаем дамп базы данных
Write-Host "Создание дампа базы данных $DatabaseName..."
docker exec $ContainerName pg_dump -U $UserName -d $DatabaseName > $DumpFile

# Проверяем успешность создания дампа
if ($LASTEXITCODE -eq 0) {
    Write-Host "Дамп успешно создан: $DumpFile"
} else {
    Write-Host "Ошибка при создании дампа базы данных"
    exit 1
}