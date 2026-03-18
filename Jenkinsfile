#!groovy 
properties([
    pipelineTriggers([
        cron('0 17 * * 4'), 
        cron('0 9 * * 2')  
    ])
])
node(isProtectedBranch() ? 'BlazorSample' : 'BlazorSamples') {
    timeout(time:90){
        try {
            deleteDir();

            stage('Import') {
                git url: 'https://gitea.syncfusion.com/essential-studio/ej2-groovy-scripts.git', branch: 'master', credentialsId: env.GiteaCredentialID;
                shared = load 'src/aspnet.groovy';
            }

            stage('Checkout') {
                checkout scm;
            }

            stage('Workflow Validation') {
                shared.getProjectDetails();
                shared.gitlabCommitStatus('running');
                shared.validateMRDescription();
            }

            if(shared.checkCommitMessage()) {
                stage('Install') {
                    shared.aspInstall();
                }

                stage('Code Leaks Analysis'){
                    try{
                        shared.initGitleaks();
                        shared.runShell('npm run gitleaks-test');
                    }
                    finally{
                        if(fileExists('GitLeaksReport.json'))
                        {
                            archiveArtifacts artifacts:'GitLeaksReport.json';
                        }
                    }               
                }

                stage('Build') {
                    shared.runShell('gulp update-nuget-config');
                    shared.runShell('dotnet --version');
                    if(shared.isProtectedBranch()){
                        shared.runShell('npm run update-service-urls');
                    }
                    shared.runShell('npm run build');
                    shared.artifactFiles();
                }

                stage('Deploy Build Samples'){
                    if(shared.isProtectedBranch()){
                        shared.runShell('npm run deploy-build-samples');
                    }
                }

                stage('Publish') {
                    if(shared.isProtectedBranch()) {
                        shared.runShell('gulp sitemap-generate --option local-sitemap');
                        shared.runShell('npm run publish');
                    }
                }
            }
            shared.gitlabCommitStatus('success');
            deleteDir();
        }
        catch(Exception e) {
            if(shared.isProtectedBranch()) {
                shared.runShell('gulp publish-report --platform aspnetcore');
            }
            shared.throwError(e);
            deleteDir();
        }
    }
}


def isProtectedBranch() {
    return env.githubSourceBranch == env.STAGING_BRANCH || String.valueOf(env.githubSourceBranch).startsWith('hotfix/') || String.valueOf(env.githubSourceBranch).startsWith('release/');
}
