pipeline {
    agent none
    stages {
        stage('Build') {
            agent {dockerfile true}
            steps {
                sh 'ls -la'
                echo "Building"
            }
        }
    }
}
