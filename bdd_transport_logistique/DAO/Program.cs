using repository.Repositories;

var repoEntrepot = new RepoEntrepot();
var repoExpedition = new RepoExpedition();

var listeEntrepots = repoEntrepot.FindAll();
var listeExpeditions = repoExpedition.FindAll();

/*foreach (var item in listeEntrepots)
{
    item.DisplayAllEntrepots(item);
}*/

/*foreach (var item in listeExpeditions)
{
    item.DisplayAllExpeditions(item);
}
*/
