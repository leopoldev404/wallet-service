echo "Starting Setup..."

docker-compose -f docker/docker-compose.yml up -d

echo "Init Containers! 🐋"

echo "Checking Wallet Microservice Status..."
sleep 5

url="http://localhost:6000/ok"
http_status=$(curl -o /dev/null -I -sw "%{http_code}" $url)
if [ $http_status -eq 200 ]; then
    echo "Wallet Microservice is OK! ✅"
else
    echo "Wallet Microservice Failed! ❌"
fi

echo "Setup Completed! 🚀"
echo "Have fun! 🦄"