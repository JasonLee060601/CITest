pipeline {
    agent {
        docker {
            image 'mcr.microsoft.com/dotnet/sdk:6.0'
        }
    }
    stages {
        stage('Build') {
            steps {
                echo 'now doing buildingTag'
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
