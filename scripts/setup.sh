echo "Init Containers! 🚀"

docker-compose -f docker/docker-compose.yml up -d

sleep 5 
echo "Test API:"
curl http://localhost:6000/health


sleep 2
docker-compose -f docker/docker-compose.yml down
