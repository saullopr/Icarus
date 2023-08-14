using UnityEngine;

public enum ArtifactType {
    Blue,
    Green,
    Orange,
    Red,
    Yellow,
}

public class Artifact : MonoBehaviour {
    [SerializeField] private ArtifactType _type;
    
    private void OnTriggerEnter(Collider other) {
        ArtifactManager.I.CollectArtifact(_type);

        Destroy(gameObject);
    }
}
