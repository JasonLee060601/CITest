pipeline {
    agent any
    environment {
        registry = "myapp"  // Change this to your preferred image name
        img = "$registry:${env.BUILD_ID}"
        DOCKERFILE_DIR = "CITest/Dockerfile" // Change this to your Dockerfile path
        DOTNET_ROOT = "/var/jenkins_home/tools/io.jenkins.plugins.dotnet.DotNetSDK/.NET_6"
        PATH = "${DOTNET_ROOT}:${PATH}"
    }
    
    stages {
         stage('Check dotnet') {
            steps {
                sh 'echo $PATH'
                sh 'ls -l $DOTNET_ROOT'
                sh '$DOTNET_ROOT/dotnet.exe --version'
            }
        }
        stage('Checkout') {
            steps {
                echo 'Checking out repository...'
                git branch: 'main', url: 'https://github.com/JasonLee060601/CITest.git'
                sh 'ls -la'
            }
        }
        stage('Build Application') {
            steps {
                echo 'Building application...'
                sh '$DOTNET_ROOT/dotnet build --configuration Release'
            }
        }
        stage('Create Docker Image') {
            steps {
                echo 'Building Docker image...'
                sh "docker build -t ${img} ${DOCKERFILE_DIR}"
            }
        }
        stage('Run Docker Container') {
            steps {
                echo 'Running container...'
                sh "docker run --rm -d --name ${JOB_NAME} -p 8081:5000 ${img}"
            }
        }
        stage('Verify Docker Image') {
            steps {
                echo 'Listing available Docker images...'
                sh "docker images | grep ${registry}"
            }
        }
    }
    post {
        always {
            echo 'Pipeline completed'
        }
        success {
            echo 'Pipeline succeeded!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
