pipeline {
    agent none
        stages {
            stage ('Run') {
                steps {
                    script {
                        img = docker.build('teste-jenkins')

                            img.inside('--entrypoint= -e dotnet ./app/StudentsApp.dll') {
                                sh '''
                                    echo "worked"
                                    '''
                            }   
                    }
                }
            }
        }
}
