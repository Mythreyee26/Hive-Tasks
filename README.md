sudo yum update -y
sudo yum install git -y

git clone https://github.com/Mythreyee26/Hive-learning.git
cd Hive-learning


dotnet:

sudo amazon-linux-extras enable docker
sudo yum install -y docker

sudo service docker start

sudo usermod -aG docker $USER

docker --version
sudo dnf install -y dotnet-sdk-8.0
dotnet --version

Commands:

sudo docker build -t dotnet-app .
docker run -d -p 80:5000 -e DOTNET_URLS="http://+:80" dotnet-env


NODEAPP

sudo yum update -y

# Install Docker (already installed in your case)
sudo yum install -y docker

# Start and enable Docker service
sudo systemctl start docker
sudo systemctl enable docker

# Add current user to docker group (avoid using sudo for docker commands)
sudo usermod -aG docker $USER

# Log out and log back in for group change to apply

# Install Node.js LTS from NodeSource
curl -fsSL https://rpm.nodesource.com/setup_lts.x | sudo bash -
sudo yum install -y nodejs

# Check versions
node -v
npm -v
docker --version


cOMMANDS: TO BUILD AND RUN

docker build -t env-node-app .

docker run -d -p 80:3000 \
  -e MESSAGE="Hello from EC2 Docker!" \
  -e NODE_ENV="production" \
  env-node-app
