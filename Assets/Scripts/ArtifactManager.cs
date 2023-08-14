using System;
using System.Linq;
using UnityEngine;

public class ArtifactManager : MonoBehaviour {
    #region Singleton

    private static ArtifactManager _i;

    public static ArtifactManager I {
        get {
            if (_i == null) {
                _i = FindObjectOfType<ArtifactManager>() ?? new GameObject(nameof(ArtifactManager))
                   .AddComponent<ArtifactManager>();
            }

            return _i;
        }
    }

    #endregion

    [SerializeField] private ArtifactSet[] _artifacts;
    [SerializeField] private GameObject _artifactCombined;

    private void Start() {
        foreach (var artifact in _artifacts) {
            artifact.Artifact.SetActive(false);
        }
        
        _artifactCombined.SetActive(false);
    }

    public void CollectArtifact(ArtifactType artifactType) {
        var set = _artifacts.First(x => x.Type == artifactType);
        
        set.IsCollected = true;
        set.Artifact.SetActive(true);
    }

    public bool HasAllArtifacts() {
        return _artifacts.All(x => x.IsCollected);
    }

    public void EnableCombo() {
        foreach (var artifact in _artifacts) {
            artifact.Artifact.SetActive(false);
        }

        _artifactCombined.SetActive(true);
    }

    [Serializable]
    public class ArtifactSet {
        [SerializeField] private GameObject _artifact;

        public GameObject Artifact => _artifact;

        [SerializeField] private ArtifactType _type;

        public ArtifactType Type => _type;

        public bool IsCollected { get; set; }
    }
}
