pipeline {
        stages {
            stage ('Run') {
                agent {dockerfile true}
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
