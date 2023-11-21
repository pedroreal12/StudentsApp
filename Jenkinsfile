pipeline {
    agent none
        stages {
            stage ('Build') {
                steps{
                    script {
                        docker.build('-f ./Dockerfile .').inside() {
                            sh 'dotnet ./app/StudentsApp.dll'
                        }
                    }
                }
            }
        }
}
