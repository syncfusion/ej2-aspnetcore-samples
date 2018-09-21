#!groovy

node('EJ2Samples') {
    try {
        deleteDir();

        stage('Import') {
            git url: 'https://gitlab.syncfusion.com/essential-studio/ej2-groovy-scripts.git', branch: 'master', credentialsId: env.JENKINS_CREDENTIAL_ID;
            shared = load 'src/shared.groovy';
        }

        stage('Checkout') {
            checkout scm;
            shared.getProjectDetails();
            shared.gitlabCommitStatus('running');
        }
        
        if(shared.checkCommitMessage()) {
            stage('Install') {
                shared.install();
            }

            stage('Publish') {
                shared.runShell('npm run aspnet-publish');
            }

            stage('Deploy') {
                if(shared.isProtectedBranch()) {
                    shared.runShell('npm run ci-deploy');
                }
            }
        }

        shared.gitlabCommitStatus('success');
        deleteDir();
    }
    catch(Exception e) {
        shared.throwError(e);
    }
}