pipeline {
    agent any
    stages {
        stage('Setup') {
            steps {
                sh '''
                wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
                dpkg -i packages-microsoft-prod.deb
                apt-get update
                apt-get install -y dotnet-sdk-6.0
                '''
            }
        }
        stage('Build') {
            steps {
                echo 'now doing buildingTag'
                sh 'dotnet restore'
                sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                echo 'Running unit tests...'
                sh 'dotnet test WeatherForecast.API.Test/WeatherForecast.API.Test.csproj'
                
                // To publish test results:
                mstest testResultsFile:"**/*.trx", keepLongStdio: true
            }
        }
    }
    post {
        always {
            echo 'Pipeline completed'
            // You can add steps to always run after the pipeline, such as:
            // cleanWs() // Clean workspace
        }
        success {
            echo 'Pipeline succeeded!'
        }
        failure {
            echo 'Pipeline failed!'
        }
    }
}
