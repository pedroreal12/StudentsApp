pipeline {
    agent none
        stages {
            stage ('Build') {
                script {
                    docker.build('-f ./Dockerfile .').inside() {
                        sh 'dotnet ./app/StudentsApp.dll'
                    }
                }
            }
        }
}
