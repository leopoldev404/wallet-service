echo "Starting Setup..."

if ! (docker ps | grep -q "postgres-container-wallet") || ! (docker ps | grep -q "mongo-container-wallet") || ! (docker ps | grep -q "wallet-service-container"); then
    docker-compose -f docker/docker-compose.yml down
    docker-compose -f docker/docker-compose.yml up -d
    sleep 5 
fi
echo "Init Containers! 🚀"

url="http://localhost:6000/ok"
http_status=$(curl -o /dev/null -I -sw "%{http_code}" $url)
if [ $http_status -eq 200 ]; then
    echo "Wallet Service is OK! ✅"
else
    echo "Wallet Service Failed! ❌"
fi

echo "Postgres Setup..."
./scripts/postgres-setup.sh

echo "Setup Completed! ✅"