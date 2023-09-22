echo "Init Containers! 🚀"

docker-compose -f docker/docker-compose.yml up -d

sleep 1

echo "Test API:"
curl http://localhost:6000/health

sleep 1

docker-compose -f docker/docker-compose.yml down
