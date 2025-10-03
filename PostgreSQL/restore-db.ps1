# Скрипт для восстановления базы данных PostgreSQL из дампа

# Параметры подключения к базе данных
$ContainerName = "postgres-db"
$DatabaseName = "mydb"
$UserName = "postgres"
$DumpFile = "dump.sql"

# Проверяем наличие файла дампа
if (-not (Test-Path $DumpFile)) {
    Write-Host "Файл дампа не найден: $DumpFile"
    exit 1
}

# Восстанавливаем базу данных из дампа
Write-Host "Восстановление базы данных $DatabaseName из дампа..."
docker exec -i $ContainerName psql -U $UserName -d $DatabaseName < $DumpFile

# Проверяем успешность восстановления
if ($LASTEXITCODE -eq 0) {
    Write-Host "База данных успешно восстановлена из дампа: $DumpFile"
} else {
    Write-Host "Ошибка при восстановлении базы данных из дампа"
    exit 1
}