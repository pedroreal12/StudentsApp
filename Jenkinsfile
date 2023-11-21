pipeline {
    agent {dockerfile true}
        stages {
            stage('Restore packages'){
                steps{
                    sh 'dotnet restore ./app/StudentsApp.sln'
                }
            }
            stage('Clean'){
                steps{
                    sh 'dotnet clean StudentsApp.sln'
                }
            }
            stage('Build'){
                steps{
                    sh 'dotnet build StudentsApp.sln' 
                }
            }
            stage('Publish'){
                steps{
                    sh 'dotnet publish StudentsApp/Students.csproj' 
                }
            }
            stage('Deploy'){
                steps{
                    sh '''
                        ARG UID=10001
                        RUN adduser \
                        --disabled-password \
                        --gecos "" \
                        --home "/nonexistent" \
                        --shell "/sbin/nologin" \
                        --no-create-home \
                        --uid "${UID}" \
                        appuser
                        USER appuser
                        kill -9 $pid
                        '''
                        sh 'cd ./app/StudentsApp/'
                }
            }
        }
}
