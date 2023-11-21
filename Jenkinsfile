pipeline {
    agent none
        stages {
            stage ('Run') {
                script {
                    img = docker.build('-f ./Dockerfile')

                        img.inside('--entrypoint= -e dotnet ./app/StudentsApp.dll') {
                            sh '''
                                echo "worked"
                            '''
                        }   
                }
            }
        }
