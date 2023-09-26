echo "Starting Setup..."

docker-compose -f docker/docker-compose.yml down

docker volume rm docker_postgres_data
docker volume rm docker_mongodb_data

docker-compose -f docker/docker-compose.yml up -d

echo "Init Containers! 🐋"

sleep 5

url="http://localhost:6000/ok"
http_status=$(curl -o /dev/null -I -sw "%{http_code}" $url)
if [ $http_status -eq 200 ]; then
    echo "Wallet Service is OK! ✅"
else
    echo "Wallet Service Failed! ❌"
fi



echo "Setup Completed! 🚀"
echo "Have fun! 🦄"