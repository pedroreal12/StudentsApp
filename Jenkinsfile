pipeline {
    agent {dockerfile true}
        stages {
            stage ('Run') {
                steps {
                    sh '''
                        ls -al
                        cd ./app/
                        dotnet ./StudentsApp.dll
                    '''
                }
            }
        }
}
